import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, FormFeedback } from 'reactstrap';
import SubmitButton from './common/SubmitButton';
import { getRanks } from '../helpers/utils';
import isURL from 'validator/lib/isURL';

export class SearchForm extends Component {
    static displayName = SearchForm.name;

    constructor(props) {
        super(props);

        this.state = {
            search: 'online title search',
            url: 'www.infotrack.com.au',
            loading: false,
            validate: {
                searchState: 'has-success',
                urlState: 'has-success'
            }
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value,
        });
    }

    // return appropriate property to change based on the input
    validateSearch = e => {
        const { validate } = this.state
        if (e.target.value.length > 0) {
            validate.searchState = 'has-success' 
        } else {
            validate.searchState = 'has-danger'
        }
        this.setState({ validate })
    }

    validateUrl = e => {
        const { validate } = this.state
        if (isURL(e.target.value)) {
            validate.urlState = 'has-success' 
        } else {
            validate.urlState = 'has-danger'
        }
        this.setState({ validate })
    }

    handleSubmit = (e) => {
        e.preventDefault();
        this.setState({ loading: true }, this.fetchRanks);
    }

    fetchRanks = () => {
        const { search, url } = this.state;
        const data = { search };

        fetch('https://localhost:44389/api/search', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data),
        })
            .then(resp => resp.json())
            .then(json => {
                const ranks = getRanks(json, url);
                this.props.setRanks(ranks);
                })
            .catch((error) => {
                console.error('Error:', error);
            })
            .finally(() => {
                this.setState({ loading: false });
            })
    }

    render() {
        const { search, url, loading, validate } = this.state;

    return (
        <Form onSubmit={this.handleSubmit}>
            <FormGroup>
                <Label for="search">Search</Label>
                <Input
                    id="search"
                    name="search"
                    type="text"
                    placeholder="What do you want to search in Google"
                    value={search}
                    valid={validate.searchState === 'has-success'}
                    invalid={validate.searchState === 'has-danger'}
                    onChange={e => {
                        this.validateSearch(e)
                        this.handleChange(e)
                    }}
                />
                <FormFeedback valid>This is what will be searched through Google</FormFeedback>
                <FormFeedback invalid>The search cannot be empty</FormFeedback>
            </FormGroup>
            <FormGroup>
                <Label for="url">Company Url</Label>
                <Input
                    id="url"
                    name="url"
                    type="text"
                    placeholder="www.infotrack.com.au"
                    value={url}
                    valid={validate.urlState === 'has-success'}
                    invalid={validate.urlState === 'has-danger'}
                    onChange={e => {
                        this.validateUrl(e)
                        this.handleChange(e)
                    }}
                />
                <FormFeedback valid>This will be matched to all returned results</FormFeedback>
                <FormFeedback invalid>Please enter url in a correct format</FormFeedback>
            </FormGroup>
            <div className="submit-row">
                <SubmitButton isLoading={loading || validate.searchState === 'has-danger' || validate.urlState === 'has-danger'} />
            </div>
        </Form>
    );
  }
}

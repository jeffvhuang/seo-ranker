import React, { Component } from 'react';
import { Form, FormGroup, Label, Input } from 'reactstrap';
import SubmitButton from './common/SubmitButton';
import { getRanks } from '../helpers/utils';

export class SearchForm extends Component {
    static displayName = SearchForm.name;

    constructor(props) {
        super(props);

        this.state = {
            search: 'online title search',
            url: 'www.infotrack.com.au',
            loading: false
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value,
        });
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
    return (
        <Form onSubmit={this.handleSubmit}>
            <FormGroup>
                <Label for="search">Search</Label>
                <Input
                    id="search"
                    name="search"
                    type="text"
                    placeholder="What do you want to search in Google"
                    value={this.state.search}
                    onChange={this.handleChange} />
            </FormGroup>
            <FormGroup>
                <Label for="url">Company Url</Label>
                <Input
                    id="url"
                    name="url"
                    type="text"
                    placeholder="www.infotrack.com.au"
                    value={this.state.url}
                    onChange={this.handleChange} />
            </FormGroup>
            <div className="submit-row">
                <SubmitButton isLoading={this.state.loading} />
            </div>
        </Form>
    );
  }
}

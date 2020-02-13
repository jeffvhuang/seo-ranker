import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export class SearchForm extends Component {
    static displayName = SearchForm.name;

    constructor(props) {
        super(props);

        this.state = {
            search: 'online title search',
            url: 'www.infotrack.com.au',
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value,
        });
    }

    handleSubmit = (e) => {
        e.preventDefault();
        const { search, url } = this.state;
        const data = { search, url };

        fetch('https://localhost:44389/api/rank', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data),
        })
        .then(resp => resp.json())
        .then(json => {
            this.props.setRanks(json);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
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
            <Button type="submit">Submit</Button>
        </Form>
    );
  }
}

import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';

export class Home extends Component {
    static displayName = Home.name;

    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        console.log(data);
        fetch('https://localhost:44389/api/rank', {
            method: 'POST',
            body: data,
        });
    }

  render () {
      return (
          <div>
              <h2>SEO Ranker</h2>
              <Form onSubmit={this.handleSubmit}>
                  <FormGroup>
                      <Label for="search">Search</Label>
                        <Input id="search" name="search" type="text" placeholder="What do you want to search in Google" />
                  </FormGroup>
                  <FormGroup>
                      <Label for="rank-url">Company Url</Label>
                      <Input id="rank-url" name="rank-url" type="text" placeholder="What url do you want to rank for?" />
                  </FormGroup>
                  <Button type="submit">Submit</Button>
              </Form>
          </div>
    );
  }
}

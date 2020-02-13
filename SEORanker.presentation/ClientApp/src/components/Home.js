import React, { Component } from 'react';
import { SearchForm } from './SearchForm';
import { Ranks } from './Ranks';

export class Home extends Component {
    static displayName = Home.name;

    constructor() {
        super();

        this.state = {
            ranks: []
        }
    }

    setRanks = ranks => this.setState({ ranks });

    render() {
        return (
            <div className="main">
                <SearchForm setRanks={this.setRanks} />
                <Ranks ranks={this.state.ranks} />
            </div>
        );
    }
}

import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    displayName = NavMenu.name

    state = { series: [] }

    componentDidMount() {
        fetch('/api/timeseries')
            .then(response => response.json())
            .then(series => this.setState({ series }));
    }

    render() {
        const links = this.state.series.map(x => <LinkContainer to={`/${x}`}><NavItem><Glyphicon glyph='plus' /> {x}</NavItem></LinkContainer>);
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/'}>Fakadata</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/'} exact>
                            <NavItem>
                                <Glyphicon glyph='home' /> Home
                            </NavItem>
                        </LinkContainer>
                        {links}
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}

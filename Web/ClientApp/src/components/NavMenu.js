import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class NavMenu extends Component {
  render() {
    return (
      <nav className="navbar is-fixed-bottom is-warning">
        <div className="container">
          <Link to="Accounts" className="navbar-item">
            Accounts
          </Link>
        </div>
      </nav>
    );
  }
}

import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class NavMenu extends Component {
  render() {
    return (
      <nav className="navbar is-fixed-bottom is-warning">
        <div className="container">
          <Link to="Wines" className="navbar-item">
            Wines
          </Link>
          <Link to="Search" className="navbar-item">
            Search
          </Link>
        </div>
      </nav>
    );
  }
}

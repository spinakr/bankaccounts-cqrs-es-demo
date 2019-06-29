import React, { Component } from "react";

class HeaderBanner extends Component {
  render() {
    return (
      <header className="has-navbar-fixed-bottom">
        <section className="hero is-info">
          <div className="hero-body">
            <div className="container">
              <h1 className="title">Bank Accounts</h1>
            </div>
          </div>
        </section>
      </header>
    );
  }
}

export default HeaderBanner;

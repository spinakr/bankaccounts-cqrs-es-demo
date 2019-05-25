import React, { Component } from "react";
import NavMenu from "./NavMenu";
import HeaderBanner from "./HeaderBanner";
import Notifications from "../notifications";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <HeaderBanner />

        <div className="section">
          <div className="container is-fluid">
            <div className="columns">
              <div className="column is-three-quarters">{this.props.children}</div>
              <div className="column has-background-primary">
                <Notifications />
              </div>
            </div>
          </div>
        </div>
        <NavMenu />
      </div>
    );
  }
}

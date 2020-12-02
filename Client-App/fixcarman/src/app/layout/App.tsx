import React from "react";
import logo from "./logo.svg";
import { Header, Icon } from "semantic-ui-react";
import NavBar from "../../features/nav/NavBar";
import GarageDisplay from "../../features/garages/GarageDisplay";

function App() {
  return (
    <div className="App">
      <NavBar />
      <GarageDisplay/>
    </div>
  );
}

export default App;

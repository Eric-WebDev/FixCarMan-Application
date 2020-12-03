import React, { Fragment, useEffect, useState } from "react";
import NavBar from "../../features/nav/NavBar";
import { IUser } from "../models/user";
import axios from "axios";
import { Container } from "semantic-ui-react";
import GarageDisplay from "../../features/garages/GarageDisplay";

const App = () => {
  const [garages, setGarages] = useState<IUser[]>([]);

  useEffect(() => {
    axios
      .get<IUser[]>("https://localhost:5001/api/usersprofiles")
      .then((response) => {
        let garages: IUser[] = [];
        response.data.forEach((garage) => {
          garages.push(garage);
        });
        setGarages(garages);
      });
  }, []);

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: "7em" }}>
        <GarageDisplay garages={garages} />
      </Container>
    </Fragment>
  );
};

export default App;

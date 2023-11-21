import React from "react";
import {Routes, Route, Redirect} from "react-router";

import Home from "../components/home/Home";
import Customer from "../components/customer/Customer";

export default props => 
    <Routes>
        <Route exact path="/" Component={Home} />
        <Route path="/customers" Component={Customer} />
    </Routes>
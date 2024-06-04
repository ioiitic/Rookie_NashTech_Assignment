import simpleRestProvider from "ra-data-simple-rest";

// const API_URL = "https://r2eshop-latest.onrender.com";
const API_URL = "https://localhost:7105";

export const dataProvider = simpleRestProvider(API_URL);

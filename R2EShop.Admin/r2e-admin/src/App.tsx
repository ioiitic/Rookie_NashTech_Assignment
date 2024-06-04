import {
  Admin,
  Resource,
  ListGuesser,
  EditGuesser,
  ShowGuesser,
} from "react-admin";
import { dataProvider } from "./dataProvider";
import { authProvider } from "./authProvider";
import DeviceList from "./components/DeviceList";
import DeviceCreate from "./components/DeviceCreate";
import DeviceUpdate from "./components/DeviceUpdate";

export const App = () => (
  <Admin dataProvider={dataProvider} authProvider={authProvider}>
    <Resource
      name="devices"
      list={DeviceList}
      create={DeviceCreate}
      edit={DeviceUpdate}
    />
  </Admin>
);

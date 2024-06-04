import React from "react";
import { Create, SimpleForm, TextInput } from "react-admin";

const DeviceCreate: React.FC = (props) => (
  <Create {...props}>
    <SimpleForm>
      <TextInput source="deviceName" />
      <TextInput source="parentDeviceId" defaultValue="" />
    </SimpleForm>
  </Create>
);

export default DeviceCreate;

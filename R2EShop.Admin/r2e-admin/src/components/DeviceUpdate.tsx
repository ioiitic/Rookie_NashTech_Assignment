import React from "react";
import { Edit, SimpleForm, TextInput } from "react-admin";

const DeviceEdit: React.FC = (props) => (
  <Edit {...props}>
    <SimpleForm>
      <TextInput disabled source="id" />
      <TextInput source="deviceName" />
    </SimpleForm>
  </Edit>
);

export default DeviceEdit;

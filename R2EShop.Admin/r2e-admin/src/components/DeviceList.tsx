import React from "react";
import {
  List,
  Datagrid,
  TextField,
  EditButton,
  DeleteButton,
  TextInput,
} from "react-admin";

const postFilters = [
  <TextInput label="Device" source="DeviceName" />,
  <TextInput label="Parent" source="Parent Id" />,
];

const DeviceList: React.FC = (props) => {
  return (
    <List
      {...props}
      title="Device List"
      filters={postFilters}
      perPage={10}
      pagination={false}
    >
      <Datagrid>
        <TextField source="id" />
        <TextField source="deviceName" />
        <TextField source="parentDeviceId" />
        <EditButton />
        <DeleteButton />
      </Datagrid>
    </List>
  );
};

export default DeviceList;

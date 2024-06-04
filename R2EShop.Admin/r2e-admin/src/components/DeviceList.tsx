import React from "react";
import { List, Datagrid, TextField, FunctionField } from "react-admin";

interface Device {
  id: string;
  deviceName: string;
  childDevices: Device[] | null;
}

const renderTree = (devices: Device[] | null) => {
  if (!devices) return null;
  return devices.map((device) => (
    <div key={device.id}>
      <TextField record={device} source="deviceName" />
      {renderTree(device.childDevices)}
    </div>
  ));
};

const DeviceList: React.FC = (props) => {
  return (
    <List {...props} title="Device List" perPage={10} pagination={false}>
      <Datagrid>
        <TextField source="id" />
        <TextField source="deviceName" />
        <FunctionField
          label="Child Devices"
          render={(record: Device) => renderTree(record.childDevices)}
        />
      </Datagrid>
    </List>
  );
};

export default DeviceList;

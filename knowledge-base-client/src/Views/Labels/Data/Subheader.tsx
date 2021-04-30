import React from "react";
import { useSharedStyles } from "../../sharedStyles";

interface Props {
  title: string;
}

export const Subheader: React.FC<Props> = ({ title }) => {
  const { label } = useSharedStyles();
  return <h2 className={label}>{title}</h2>;
};

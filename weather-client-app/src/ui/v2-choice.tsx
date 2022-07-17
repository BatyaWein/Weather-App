//@ts-noCheck
import React from 'react';
import Select, { MenuPlacement, Props as SelectProps } from 'react-select';
import CreatableSelect from 'react-select/creatable';
import { SelectComponents } from 'react-select/src/components';


export type Option<T> = { label: string | React.ReactNode; value: T };

type Props<T extends string | number> = {
  options: Option<T>[];
  classNamePrefix?: string;
  isCreatable?: boolean;
  isLoading?: boolean;
  isDisabled?: boolean;
  isClearable?: boolean;
  isSearchable?: boolean;
  placeholder?: string;
  components?: Partial<SelectComponents<Option<T>>>;
  noOptionsMessage?: () => string;
  onInputChange?: (str: string) => void;
  menuPlacement?: MenuPlacement;
  className?: string;
  label?: string;
} & (
  | { isMulti: true; value: T[]; onChange: (value: T[]) => void }
  | { isMulti?: false; onChange: (value: T) => void; value: T | Array<any> | null }
);

export const V2Choice = (props: Props<T>) => {
  const {
    value,
    onChange,
    isCreatable,
    ...selectProps
  } = props;
  const Tag = (isCreatable ? CreatableSelect : Select) as React.ElementType<SelectProps<Option<T>>>;
  return (
    <div>
      <label>{value !== '' && selectProps.label ? selectProps.label : ''}</label>
      <Tag
        {...selectProps}
        value={props.options?.filter((option) => {
          if (props.isMulti) {
            // @ts-ignore
            return value?.includes(option.value);
          }
          return value === option.value;
        })}
        onChange={(changeEvent) => {
          if (!onChange) {
            return;
          }
          if (props.isMulti) {
            // @ts-ignore
            onChange((changeEvent || []).map((event) => event.value));
          } else {
            // @ts-ignore
            onChange(changeEvent?.value);
          }
        }}
        // Prevent Dropdown selection opening on keyboard
        // isSearchable={selectProps.isSearchable}
        // inputProps={{ autoComplete: 'random-string', autofill: 'off' }}
      />
    </div>
  );
};

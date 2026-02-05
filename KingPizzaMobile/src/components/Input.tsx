import { TextInput, TextInputProps } from "react-native";

export function Input({ ...rest }: TextInputProps) {
  return (
    <TextInput
      placeholderTextColor="#ED7A16" 
      className="w-full h-14 bg-gray-50 rounded-xl border border-orange-500 px-4 mb-4 text-lg focus:border-orange-500"
      {...rest}
    />
  );
}
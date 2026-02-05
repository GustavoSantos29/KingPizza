import { Text, TouchableOpacity, TouchableOpacityProps } from "react-native";


type Props = TouchableOpacityProps & {
  title: string;
  variant?: "primary" | "secondary";
};

export function Button({ title, variant = "primary", ...rest }: Props) {
  const buttonStyle =
    variant === "primary"
      ? "bg-orange-500 border-2 border-orange-500"
      : "bg-transparent border-2 rounded-6 border-orange-500";

  const textStyle =
    variant === "primary" ? "text-white" : "text-orange-500";

  return (
    <TouchableOpacity
      className={`w-full h-14 rounded-xl items-center justify-center ${buttonStyle}`}
      activeOpacity={0.7}
      {...rest}
    >
      <Text className={`text-lg font-bold ${textStyle}`}>{title}</Text>
    </TouchableOpacity>
  );
}
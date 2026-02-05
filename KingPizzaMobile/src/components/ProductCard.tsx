import { View, Text, Image, TouchableOpacity, TouchableOpacityProps } from "react-native";

export type ProductProps = {
  id: string;
  name: string;
  description: string;
  price: string;
  image?: any; 
};

type Props = TouchableOpacityProps & {
  data: ProductProps;
};

export function ProductCard({ data, ...rest }: Props) {
  return (
    <TouchableOpacity 
      className="w-full bg-white flex-row items-center p-4 border-b border-gray-200"
      {...rest}
    >
      <View className="w-24 h-24 rounded-md bg-gray-200 overflow-hidden mr-4">
        <Image 
          source={{ uri: "https://static.vecteezy.com/system/resources/previews/024/589/160/non_2x/top-view-pizza-transparent-background-free-png.png" }} 
          className="w-full h-full"
          resizeMode="cover"
        />
      </View>

      <View className="flex-1">
        <Text className="text-lg font-bold text-gray-900 mb-1">
          {data.name}
        </Text>
        
        <Text className="text-gray-500 text-xs leading-4 mb-2" numberOfLines={2}>
          {data.description}
        </Text>
        
        <Text className="text-orange-500 font-bold text-base">
          {data.price}
        </Text>
      </View>
    </TouchableOpacity>
  );
}
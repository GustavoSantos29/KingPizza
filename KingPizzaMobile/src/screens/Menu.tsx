import { View, Text, TextInput, FlatList, TouchableOpacity, Platform, StatusBar as RNStatusBar } from "react-native";
import { StatusBar } from "expo-status-bar";
import { Feather } from "@expo/vector-icons"; 
import { ProductCard, ProductProps } from "../components/ProductCard";


const MOCK_PIZZAS: ProductProps[] = [
  {
    id: "1",
    name: "Pizza de Calabresa",
    description: "Massa artesanal, molho de tomate italiano, muita calabresa fatiada e cebola roxa.",
    price: "R$ 45,00",
  },
  {
    id: "2",
    name: "Pizza Quatro Queijos",
    description: "Mussarela, provolone, parmesão e gorgonzola derretidos sobre massa fina.",
    price: "R$ 52,00",
  },
  {
    id: "3",
    name: "Pizza Frango c/ Catupiry",
    description: "Frango desfiado temperado coberto com o autêntico catupiry original.",
    price: "R$ 48,00",
  },
   {
    id: "4",
    name: "Pizza Lombo canadense",
    description: "Frango desfiado temperado coberto com o autêntico catupiry original.",
    price: "R$ 48,00",
  },
   {
    id: "5",
    name: "Pizza Frango c/ bacon",
    description: "Frango desfiado temperado coberto com o autêntico catupiry original.",
    price: "R$ 48,00",
  },
];

export function Menu() {

  const paddingTop = Platform.OS === "android" ? RNStatusBar.currentHeight! + 10 : 0;

  return (
    <View className="flex-1 bg-white">
      <StatusBar style="light" backgroundColor="#F97316" />

      <View 
        className="bg-orange-500 px-6 pb-6 rounded-b-3xl shadow-lg"
        style={{ paddingTop: paddingTop + 20 }}
      >
        <TouchableOpacity onPress={() => console.log("Abrir Menu Lateral")}>
          <Feather name="menu" size={28} color="white" />
        </TouchableOpacity>

        <Text className="text-white text-2xl font-bold mt-10 mb-4">
          O que vamos comer hoje?
        </Text>

        <View className="flex-row items-center bg-white rounded-full h-12 px-4">
          <Feather name="search" size={20} color="#9CA3AF" />
          <TextInput 
            placeholder="Pesquisar..."
            className="flex-1 ml-2 text-base text-gray-700"
            placeholderTextColor="#9CA3AF"
          />
        </View>
      </View>

      <FlatList
        data={MOCK_PIZZAS}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => (
          <ProductCard 
            data={item} 
            onPress={() => console.log("Clicou na pizza:", item.name)}
          />
        )}
        contentContainerStyle={{ paddingBottom: 20, paddingTop: 20 }}
        showsVerticalScrollIndicator={false}
      />
      
    </View>
  );
}
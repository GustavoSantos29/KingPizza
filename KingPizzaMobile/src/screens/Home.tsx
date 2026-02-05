import { StatusBar } from "expo-status-bar";
import { Text, View } from "react-native";
import { Button } from "../components/Button";
import { Logo } from "../components/Logo";


export function Home({ navigation }: any) {
  return (
    <View className="flex-1 bg-white px-8 justify-center items-center">
      <StatusBar style="dark" />
      <Logo />
      <Text className="text-orange-500 text-4xl font-extrabold mb-2 italic">
        King Pizza
      </Text>
      <Text className="text-orange-500 text-lg mb-12 text-center font-medium">
        A melhor hamburgueria da cidade
      </Text>

      <Button 
        title="Login" 
        variant="secondary" 
        onPress={() => navigation.navigate('Login')} 
      />
    </View>
  );
}
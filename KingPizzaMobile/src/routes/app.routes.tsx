import { createDrawerNavigator } from "@react-navigation/drawer";
import { Feather } from "@expo/vector-icons";
import { View, Text } from "react-native";
import { Menu } from "../screens/Menu";
import { CustomDrawer } from "../components/CustomDrawer";

const Drawer = createDrawerNavigator();

function Pedidos() {
  return (
    <View className="flex-1 bg-white justify-center items-center">
      <Text className="text-xl font-bold text-orange-500">Meus Pedidos</Text>
    </View>
  );
}
function Compras() {
  return (
    <View className="flex-1 bg-white justify-center items-center">
      <Text className="text-xl font-bold text-orange-500">Minhas compras</Text>
    </View>
  );
}

export function AppRoutes() {
  return (
    <Drawer.Navigator
    drawerContent={(props) => <CustomDrawer {...props} />}
      screenOptions={{
        headerShown: false,
        drawerActiveTintColor: "#FFFFFF",
        drawerInactiveTintColor: "#FFFFFF",
      }}
    >
      <Drawer.Screen
        name="Cardápio"
        component={Menu}
        options={{
          drawerIcon: ({ color, size }) => (
            <Feather name="home" color={color} size={size} />
          ),
        }}
      />

      <Drawer.Screen
        name="Meus Pedidos"
        component={Pedidos}
        options={{
          drawerIcon: ({ color, size }) => (
            <Feather name="list" color={color} size={size} />
          ),
        }}
      />
      <Drawer.Screen
        name="Minhas compras"
        component={Compras}
        options={{
          drawerIcon: ({ color, size }) => (
            <Feather name="shopping-cart" color={color} size={size} />
          ),
        }}
      />
    </Drawer.Navigator>
  );
}

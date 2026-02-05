import { useState } from "react";
import {
  View,
  Text,
  Alert,
  KeyboardAvoidingView,
  Platform,
  ScrollView,
  Dimensions,
} from "react-native";
import { Button } from "../components/Button";
import { Input } from "../components/Input";
import { StatusBar } from "expo-status-bar";
import { Logo } from "../components/Logo";

const screenHeight = Dimensions.get("window").height;

export function Login({ navigation }: any) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  function handleLogin() {
    if (email && password) {
      navigation.navigate("Menu");
    } else {
      Alert.alert("Erro", "Preenche tudo aí");
    }
  }

  return (
    <View className="flex-1 bg-white">
      <StatusBar style="dark" />

      <KeyboardAvoidingView
        style={{ flex: 1 }}
        behavior={Platform.OS === "ios" ? "padding" : "height"}
        keyboardVerticalOffset={Platform.OS === "ios" ? 0 : 20}
      >
        <ScrollView
          showsVerticalScrollIndicator={false}
          contentContainerStyle={{ paddingBottom: 50 }}
          keyboardShouldPersistTaps="handled"
        >
          <View
            className="px-8 justify-center"
            style={{ minHeight: screenHeight - 100 }}
          >
            <View className="w-full items-center">
              <Logo width={130} height={220} />

              <Text className="text-orange-500 text-2xl mb-8 text-center font-bold">
                Login
              </Text>

              <View className="w-full">
                <Input
                  placeholder="E-mail"
                  keyboardType="email-address"
                  autoCapitalize="none"
                  value={email}
                  onChangeText={setEmail}
                />

                <Input
                  placeholder="Senha"
                  secureTextEntry
                  value={password}
                  onChangeText={setPassword}
                />
              </View>

              <View className="flex-row mt-4 w-full">
                <View className="flex-1 mr-2">
                  <Button
                    title="Voltar"
                    variant="secondary"
                    onPress={() => navigation.goBack()}
                  />
                </View>

                <View className="flex-1 ml-2 mb-4">
                  <Button title="Entrar" onPress={handleLogin} />
                </View>
              </View>
              <View className="flex-1 ">
                <Button
                  title="Cadastro"
                  onPress={() => navigation.navigate("Cadastro")}
                />
              </View>
            </View>
          </View>
        </ScrollView>
      </KeyboardAvoidingView>
    </View>
  );
}

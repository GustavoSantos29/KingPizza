import React from 'react';
import { View, Text, Image } from 'react-native';
import { DrawerContentScrollView, DrawerItemList } from '@react-navigation/drawer';

export function CustomDrawer(props: any) {
  return (
    <View className="flex-1 bg-orange-500"> 
      
      <View className="h-40 bg-orange-500 items-center justify-center p-4">
        <View className="w-16 h-16 bg-white rounded-full items-center justify-center mb-2">
            <Text className="text-orange-500 font-bold text-xl">KP</Text>
        </View>
        <Text className="text-white font-bold text-lg">King Pizza</Text>
      </View>

      <DrawerContentScrollView {...props} contentContainerStyle={{ paddingTop: 20 }}>
        <DrawerItemList {...props} />
      </DrawerContentScrollView>

      <View className="p-4 border-t border-orange-300">
        <Text className="text-gray-100 text-sm">Versão 1.0.0</Text>
      </View>

    </View>
  );
}
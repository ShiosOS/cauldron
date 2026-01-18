<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { api } from '@/api'

const status = ref('')

onMounted(async () => {
  const data = await api('/api/health')
  status.value = data.status
})
</script>

<template>
  <div>
    <h1>Cauldron</h1>
    <p>Backend status: {{ status }}</p>
  </div>
</template>

<style scoped></style>

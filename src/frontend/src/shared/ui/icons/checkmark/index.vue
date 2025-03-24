<script setup>
defineProps({
      width: {
        type: Number,
        default: 18
      },
      height: {
        type: Number,
        default: 14
      },
      color: {
        type: String,
        default: '#7A5CFA'
      }
    }
)
</script>

<template>
  <svg
      :height="height"
      :width="width"
      fill="none"
      xmlns="http://www.w3.org/2000/svg">
    <path
        :fill="color"
        d="M5.99997 11.17L1.82997 7L0.409973 8.41L5.99997 14L18 2L16.59 0.589996L5.99997 11.17Z"/>
  </svg>
</template>

<style scoped>

</style>
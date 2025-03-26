<script setup>
defineProps({
      width: {
        type: Number,
        default: 12
      },
      height: {
        type: Number,
        default: 9
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
        d="M1.41 0.589996L6 5.17L10.59 0.589996L12 2L6 8L0 2L1.41 0.589996Z"/>
  </svg>
</template>

<style scoped>

</style>
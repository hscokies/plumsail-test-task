<script setup>
defineProps({
      width: {
        type: Number,
        default: 24
      },
      height: {
        type: Number,
        default: 24
      },
      color: {
        type: String,
        default: '#7A5CFA'
      }
    }
)
</script>

<template>
  <svg :height="height"
       :stroke="color"
       :width="width"
       fill="none"
       stroke-linecap="round"
       stroke-linejoin="round"
       stroke-width="2"
       xmlns="http://www.w3.org/2000/svg">
    <path d="M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71"/>
    <path d="M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71"/>
  </svg>
</template>

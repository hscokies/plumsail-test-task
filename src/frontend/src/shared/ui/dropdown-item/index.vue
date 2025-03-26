<script setup>
defineProps({
  label: String
})

defineEmits(["selected"]);
</script>

<template>
  <li class="dropdown-item" @click="$emit('selected', $event)">
    {{ label }}
  </li>
</template>

<style scoped>
.dropdown-item {
  list-style: none;

  text-align: left;
  padding: 16px;

  background-color: #FFF;
  outline: 1px solid #CCC;

  font-size: 16px;
  line-height: 24px;
  color: #333;

  transition: background-color .2s ease-in-out;

  &:hover {
    background-color: #7A5CFA;
    color: #FFF;
  }
}
</style>
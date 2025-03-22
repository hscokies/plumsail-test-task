<script setup>
import HelloWorld from '../components/HelloWorld.vue'
import { TextField, FormGroup, RadioButton, Checkbox, Dropdown, DropdownItem} from '@/shared/ui'
import {ref} from "vue";

const textValue = ref('');
const activeRb = ref(0);
const assignees = ref(new Set([]));
const selectedItem = ref(null);
const OnChange = (event) => {
  textValue.value = event.target.value;
}

const OnRbCheck = (event, index) => {
  if (event.target.checked) {
    activeRb.value = index;
  }
}

const OnCbCheck = (event, value) => {
  if (event.target.checked) {
    assignees.value.add(value);
  }
  else{
    assignees.value.delete(value);
  }
}

const OnSelect = (event, value) => {
  selectedItem.value = value;
}
</script>

<template>
  <div>
    <a href="https://vite.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="../assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <HelloWorld msg="Vite + Vue" />
  <form style="background-color: white; padding: 20px;">
    <Dropdown
        label="Dropdown title"
        placeholder="this is dropdown placeholder"
        :value="selectedItem">
      <DropdownItem
          label="dropdown-item 1"
          @selected="e => OnSelect(e, 'dropdown-item 1')"/>
      <DropdownItem
          label="dropdown-item 2"
          @selected="e => OnSelect(e, 'dropdown-item 2')"/>
    </Dropdown>
    
    <TextField
        id="username"
        name="username"
        label="Username"
        error
        error-message="Username is required"
        placeholder="Enter username"/>
    
    <TextField
        id="password"
        name="password"
        label="Password"
        placeholder="Enter password"
        helper-text="Your password is between 4 and 12 characters"
        type="password"
        :value="textValue"
        @changed="OnChange" />
    
    <FormGroup label="Options">
      <RadioButton
          id="rb1"
          name="g1"
          label="Radio selection 1"
          value="Radio selection 1"
          :checked="activeRb === 1"
          @changed="e => OnRbCheck(e, 1)"
          />
      <RadioButton
          id="rb2"
          name="g1"
          label="Radio selection 2"
          value="Radio selection 2"
          :checked="activeRb === 2"
          @changed="e => OnRbCheck(e, 2)"/>
    </FormGroup>
    
    <FormGroup label="Assign responsibility" error="this is error">
      <Checkbox
          id="cb1"
          name="cb1"
          label="Gilad Gray"
          value="Gilad Gray"
          :checked="assignees.has('Gilad Gray')"
          @changed="e => OnCbCheck(e, 'Gilad Gray')"/>

      <Checkbox
          id="cb2"
          name="cb2"
          label="Jason Killian"
          value="Jason Killian"
          :checked="assignees.has('Jason Killian')"
          @changed="e => OnCbCheck(e, 'Jason Killian')"/>
    </FormGroup>
  </form>
  <HelloWorld msg="Vite + Vue" />
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>

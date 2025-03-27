<script setup>
import {DownArrow} from '@/shared/ui/icons'
import {nextTick, onMounted, onUnmounted, ref} from "vue";
import {useOutsideClick} from "@/shared/lib/index.js";

defineProps({
  id: String,
  name: String | Number,
  label: String,
  placeholder: String,
  error: String,
  color: String,
  value: String,
})
const {elementRef, active, toggleActive} = useOutsideClick(false);
const inputRef = ref(null)
const menuRef = ref(null)
const errorRef = ref(null)

const toggle = async () => {
  toggleActive()
  await nextTick();
  adjust();
}

const adjust = () => {

  if (!inputRef.value || !menuRef.value || !elementRef.value) {
    return;
  }

  const availableHeight = window.innerHeight;
  const inputRect = inputRef.value.getBoundingClientRect();
  const menuRect = menuRef.value.getBoundingClientRect();

  if (inputRect.bottom + menuRect.height > availableHeight) {
    menuRef.value.style.transform = `translateY(-${menuRect.height}px)`;
    inputRef.value.classList.add('top')
    inputRef.value.classList.remove('bottom')
    return;
  }

  const componentHeight = elementRef.value.getBoundingClientRect().height;
  menuRef.value.style.transform = `translateY(${componentHeight}px)`;
  inputRef.value.classList.add('bottom')
  inputRef.value.classList.remove('top')
}

onMounted(() => {
  document.addEventListener("scroll", adjust);
})

onUnmounted(() => {
  document.removeEventListener("scroll", adjust);
})


</script>

<template>
  <div class="dropdown_root" @click="toggle">
    <div ref="elementRef" class="dropdown_wrapper">
      <label :for="id" class="dropdown_label">
        {{ label }}
      </label>
      <div ref="inputRef" :class="['dropdown_input', active && 'active', error?.length > 0 && 'error']">
        {{ value || placeholder }}
        <DownArrow :color="error?.length > 0 ? '#EB5757' : color" class="dropdown_input_arrow"/>
      </div>
      <ul v-if="active" ref="menuRef" class="dropdown_elements">
        <slot></slot>
      </ul>
    </div>
    <span ref="errorRef" :class="['dropdown_error-text', error?.length > 0 && 'active']">
      {{ error }}
    </span>
  </div>
</template>

<style scoped>
.dropdown_root {
  position: relative;

  user-select: none;
  -moz-user-select: none;
  -webkit-user-select: none;
  -ms-user-select: none;
}

.dropdown_root, .dropdown_wrapper {
  width: 100%;
  display: inline-flex;
  flex-direction: column;
}

.dropdown_label {
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #666;

  margin-bottom: 8px;
}

.dropdown_input {
  display: inline-flex;
  align-items: center;
  justify-content: space-between;

  padding: 16px;
  background-color: transparent;
  border-radius: 8px;
  font-size: 16px;
  line-height: 24px;
  color: #333;
  outline: 1px solid #ccc;

  cursor: pointer;
  transition: outline-color .2s ease-in-out;

  &:hover, &:focus, &.active {
    outline: 2px solid #7A5CFA;
  }

  &.error {
    outline-color: #EB5757;
  }

  &.active {
    &.bottom {
      border-bottom-left-radius: 0;
      border-bottom-right-radius: 0;
    }

    &.top {
      border-top-left-radius: 0;
      border-top-right-radius: 0;
    }
  }

  &.active > .dropdown_input_arrow {
    rotate: 180deg;
  }
}

.dropdown_input_arrow {
  transition: rotate .2s ease-in-out;
}

.dropdown_elements {
  position: absolute;
  z-index: 2;
  top: 0;
  left: 0;
  width: 100%;
  background: white;
  margin: 0;
  padding: 0;
}

.dropdown_error-text {
  visibility: hidden;
  margin-top: 8px;
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  min-height: 18px;
  color: #EB5757;

  &.active {
    visibility: visible;
  }
}
</style>
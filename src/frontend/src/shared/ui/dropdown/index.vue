<script setup>
import {DownArrow} from '@/shared/ui/icons'
import {nextTick, onMounted, onUnmounted, ref} from "vue";
import {useOutsideClick} from "@/shared/lib/index.js";
defineProps({
  id: String,
  label: String,
  placeholder: String,
  value: String,
})
const { elementRef, active, toggleActive } = useOutsideClick(false);

const inputRef = ref(null)
const menuRef = ref(null)

const toggle = async () => {
  toggleActive()
  await nextTick();
  adjust();
}

const adjust = () => {
  
  if (!inputRef.value || !menuRef.value) {
    return;
  }
  
  const availableHeight = window.innerHeight;
  const inputRect = inputRef.value.getBoundingClientRect();
  const menuRect = menuRef.value.getBoundingClientRect();
  
  if (inputRect.bottom + menuRect.height > availableHeight){
    menuRef.value.classList.add('top')

    inputRef.value.classList.add('top')
    inputRef.value.classList.remove('bottom')
    return;
  }
  menuRef.value.classList.remove('top')
  
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
  <div class="dropdown_root" @click="toggle" ref="elementRef">
    <label class="dropdown_label" :for="id">
      {{label}}
    </label>
    <div :class="['dropdown_input', active && 'active']" ref="inputRef">
      {{ value || placeholder }}
      <DownArrow class="dropdown_input_arrow"/>
    </div>
    <ul v-if="active" class="dropdown_elements" ref="menuRef">
      <slot></slot>
    </ul>
  </div>
</template>

<style scoped>
.dropdown_root{
  position: relative;

  width: 100%;
  display: inline-flex;
  flex-direction: column;
  
  user-select: none;
  -moz-user-select: none;
  -webkit-user-select: none;
  -ms-user-select: none;
}

.dropdown_label{
  text-align: left;
  line-height: 18px;
  font-size: 12px;
  font-weight: 600;
  color: #666;
  
  margin-bottom: 8px;
}

.dropdown_input{
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
  
  &:hover,&:focus, &.active{
    outline: 2px solid #7A5CFA;
  }
  
  &.active{
    &.bottom{
      border-bottom-left-radius: 0;
      border-bottom-right-radius: 0;
    }
    &.top{
      border-top-left-radius: 0;
      border-top-right-radius: 0;
    }
  }
  
  &.active > .dropdown_input_arrow{
    rotate: 180deg;
  }
}

.dropdown_input_arrow{
  transition: rotate .2s ease-in-out;
}

.dropdown_elements{
  position: absolute;
  top: 100%;
  left: 0;
  width: 100%;
  background: white;
  margin: 0;
  padding: 0;
  
  &.top{
    transform: translateY(-150%);
  }
}
</style>
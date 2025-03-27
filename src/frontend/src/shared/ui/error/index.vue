<script setup>
import {AlertTriangle, Copy, X} from '@/shared/ui/icons'
import {ref} from "vue";

const props = defineProps({
  title: {
    type: String,
    default: "Something went wrong!"
  },
  traceId: String,
})

const active = ref(true)

const copyTraceId = () => {
  navigator.clipboard.writeText(props.traceId)
}

</script>

<template>
  <Teleport v-if="active" to="body">
    <div class="error-root">
      <div class="error-wrapper">
        <div class="error-header">
          <div class="error-title-container">
            <AlertTriangle/>
            <h5>
              {{ title }}
            </h5>
          </div>
          <span class="error-close">
            <X color="#808080" @click="() => active = false"/>
          </span>
        </div>
        <div v-if="traceId" class="error-trace-information" @click="copyTraceId">
          <span class="error-trace-id">
            {{ traceId.substring(3, 33) }}
          </span>
          <Copy/>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
.error-root {
  position: fixed;
  bottom: 0;

  pointer-events: none;

  display: flex;
  justify-content: end;
  width: 100%;
  padding: 24px 24px 24px 0;

  @media (max-width: 640px) {
    justify-content: center;
    padding: 12px;
  }
}

.error-wrapper {
  display: flex;
  gap: 12px;
  align-items: flex-start;
  flex-flow: column nowrap;
  position: relative;
  border-radius: 16px;
  padding: 12px 16px;
  width: 100%;
  max-width: 500px;

  background-color: #FCE2E2;

  & .error-header {
    width: 100%;
    display: flex;
    flex-flow: row nowrap;
    justify-content: space-between;
  }

  & .error-title-container {
    display: flex;
    flex-flow: row nowrap;
    align-items: center;
    font-size: 20px;
    font-weight: 600;
    gap: 9px;

    & h5 {
      margin: 0;
    }
  }

  & .error-close {
    pointer-events: all;
    cursor: pointer;
  }

  & .error-trace-information {
    cursor: pointer;
    width: 100%;
    display: flex;
    flex-flow: row nowrap;
    align-items: center;
    gap: 9px;
    font-weight: 300;
  }
}
</style>
<script setup>
import {useMutation, useQuery} from '@tanstack/vue-query'
import {formsApi, submissionsApi} from '@/shared/api'
import {Button, BUTTON_VARIANTS, Error, FORM_BLOCK_VARIANTS, FormBlock} from "@/shared/ui/index.js";
import {
  DateQuestion,
  MultiOptionsQuestion,
  OpenQuestion,
  OptionsQuestion,
  QUESTION_TYPE,
  SelectionQuestion
} from '@/entities'
import {computed, ref} from "vue";
import {useRoute} from "vue-router";
import {useThrottleFn} from "@vueuse/core";

const route = useRoute();
const formId = computed(() => route.params.id);
const isSubmitted = ref(false);

const {isPending, data, isError: IsFetchError, error: fetchError} = useQuery({
  queryKey: ['get-form', formId.value],
  queryFn: () => formsApi.getById(formId.value)
});

const {mutate, data: InterviewId, isError: IsSubmitError, error: submissionError} = useMutation({
  mutationFn: (submission) => submissionsApi.submit(submission),
  onSuccess: () => isSubmitted.value = true,
});

const getQuestion = (type) => {
  return {
    [QUESTION_TYPE.OpenQuestion]: OpenQuestion,
    [QUESTION_TYPE.DateQuestion]: DateQuestion,
    [QUESTION_TYPE.SelectionQuestion]: SelectionQuestion,
    [QUESTION_TYPE.SingleOptionQuestion]: OptionsQuestion,
    [QUESTION_TYPE.MultipleOptionsQuestion]: MultiOptionsQuestion,
  }[type]
}

const questionsRef = ref(new Set());

const addQuestionRef = (questionComponent, questionData) => {
  if (questionComponent) {
    questionsRef.value.add({
      ref: questionComponent,
      $type: questionData.$type,
      id: questionData.id
    })
  }
}
const onSubmit = useThrottleFn(() => {
  const request = {formId: formId.value, answers: []};
  let hasErrors = false;
  for (let question of questionsRef.value) {
    if (!question.ref.triggered) {
      question.ref.validate();
    }

    if (question.ref.error) {
      hasErrors = true;
      continue;
    }

    if (question.ref.value) {
      request.answers.push({
        $type: question.$type,
        questionId: question.id,
        value: question.ref.value,
      });
    }
  }
  if (hasErrors) {
    return;
  }

  mutate(request);
}, 1000);

</script>

<template>
  <div class="form-page">
    <form class="form-page_wrapper" @submit.prevent="onSubmit">
      <input aria-hidden="true" disabled style="display: none" type="submit"/>
      <FormBlock :color="data?.color" :loading="isPending || IsFetchError" :variant="FORM_BLOCK_VARIANTS.ACCENT">
        <h1 class="form-page_header_title">{{ data?.title }}</h1>
        <p v-if="!isSubmitted" class="form-page_header_subtitle">{{ data?.subtitle }}</p>
        <div v-else>
          <p class="form-page_header_subtitle">Your response has been recorded.</p>
          <p class="form-page_header_subtitle">Interview ID: {{ InterviewId }}</p>
        </div>
      </FormBlock>

      <FormBlock v-for="question in [1,2,3,4]" v-if="IsFetchError || isPending" :key="question.id" :loading="true"/>

      <FormBlock v-for="question in data.questions" v-if="data && !isSubmitted" :key="question.id">
        <component
            :is="getQuestion(question.$type)"
            :ref="q => addQuestionRef(q, question)"
            :question="question"
        />
      </FormBlock>

      <div v-if="data" class="form-page_button-container">
        <Button v-if="!isSubmitted" :variant="BUTTON_VARIANTS.Primary" type="submit">Submit</Button>
        <Button
            v-if="isSubmitted"
            :variant="BUTTON_VARIANTS.Secondary"
            type="button"
            @click="() => isSubmitted = false">
          Submit another response
        </Button>
      </div>
    </form>
  </div>
  <Error v-if="IsSubmitError || IsFetchError" :trace-id="fetchError?.traceId || submissionError?.traceId"/>
</template>

<style scoped>
.form-page {
  display: flex;
  flex-flow: column nowrap;
  align-items: center;
}

.form-page_wrapper {
  display: flex;
  flex-flow: column nowrap;
  justify-content: center;
  align-items: center;
  gap: 15px;
  height: 100%;
  width: 70%;

  @media (max-width: 640px) {
    width: 100%;
  }
}

.form-page_header_title {
  color: #333;
  font-size: 32px;
  line-height: 48px;
  margin: 0;
}

.form-page_header_subtitle {
  color: #666;
  font-size: 20px;
  line-height: 30px;
}

.form-page_button-container {
  width: 100%;
  display: flex;
  flex-flow: row nowrap;
  justify-content: start;
  gap: 62px;
}

</style>
<script setup>
import MockData from './data.json'
import {FormBlock, FORM_BLOCK_VARIANTS, Button, BUTTON_VARIANTS} from "@/shared/ui/index.js";
import {QUESTION_TYPE, OpenQuestion, DateQuestion, SelectionQuestion, OptionsQuestion, MultiOptionsQuestion} from '@/entities'
import {ref} from "vue";

const getQuestion = (type) => {
  return {
    [QUESTION_TYPE.OpenQuestion]: OpenQuestion,
    [QUESTION_TYPE.DateQuestion]: DateQuestion,
    [QUESTION_TYPE.SelectionQuestion]: SelectionQuestion,
    [QUESTION_TYPE.OptionsQuestion]: OptionsQuestion,
    [QUESTION_TYPE.MultipleOptionsQuestion]: MultiOptionsQuestion,
  }[type]
}

const response = ref(MockData);
const questionsRef = ref(new Set());
const addQuestionRef = (questionComponent, questionData) => {
  if (questionComponent){
    questionsRef.value.add({
      ref: questionComponent,
      $type: questionData.$type,
      id: questionData.id
    })
  }
}
const onSubmit = () => {
  const request = {formId: response.id, answers: []};
  let hasErrors = false;
  for (let question of questionsRef.value) {
    question.ref.validate();
    if (question.ref.error){
      hasErrors = true;
      continue;
    }
    
    request.answers.push({
      $type: question.$type,
      id: question.id,
      value: question.ref.value,
    });
  }
  if (hasErrors) {
    return;
  }

  const json =  JSON.stringify(request, null, 2);
  console.debug("POST: /api/submissions", json);
}
</script>

<template>
  <div class="form-page">
    <form class="form-page_wrapper" @submit.prevent="onSubmit">
      <FormBlock :variant="FORM_BLOCK_VARIANTS.ACCENT" :color="response.color">
        <h1 class="form-page_header_title">{{response.title}}</h1>
        <p class="form-page_header_subtitle">{{response.subtitle}}</p>
      </FormBlock>

      <FormBlock v-for="question in response.questions" :key="question.id">
        <component
            :is="getQuestion(question.$type)"
            :ref="q => addQuestionRef(q, question)"
            :question="question"
        />
      </FormBlock>
      
      <div class="form-page_button-container">
        <Button :variant="BUTTON_VARIANTS.Primary" type="submit">Submit</Button>
      </div>
    </form>
  </div>
</template>

<style scoped>
.form-page {
  display: flex;
  flex-flow: column nowrap;
  align-items: center;
}
.form-page_wrapper{
  display: flex;
  flex-flow: column nowrap;
  justify-content: center;
  align-items: center;
  gap: 15px;
  height: 100%;
  width: 70%;

  @media (max-width: 550px) {
    width: 100%;
  }
}

.form-page_header_title{
  color: #333;
  font-size: 32px;
  line-height: 48px;
  margin: 0;
}
.form-page_header_subtitle{
  color: #666;
  font-size: 20px;
  line-height: 30px;
}

.form-page_button-container{
  width: 100%;
  display: flex;
}
</style>
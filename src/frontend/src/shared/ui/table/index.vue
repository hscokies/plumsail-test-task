<script setup>
defineProps({
  columns: Array,
  rows: Array,
  hasActions: Boolean,
})
</script>

<template>
  <table class="table">
    <thead class="table-header">
    <tr class="table-row header-row">
      <th class="table-cell header-cell" v-for="column in columns">
        {{ column.label }}
      </th>
      <th class="table-cell header-cell" v-if="hasActions">
        Actions
      </th>
    </tr>
    </thead>
    <tbody class="table-body">
    <tr class="table-row" v-for="row in rows">
      <td class="table-cell" v-for="column in columns">
        {{row[column.key]}}
      </td>
      <td class="table-cell cell-actions" v-if="hasActions">
        <slot name="data" :row="row"></slot>
      </td>
    </tr>
    </tbody>
  </table>
</template>

<style scoped>
.table{
  width: 100%;
  border-collapse: collapse;

  & .table-header{
    background: #7A5CFA;
    font-size: 16px;

  }

  .table-row{
    border-bottom: 1px solid #666;
  }

  .header-row{
    border-top: 1px solid #666;
    border-bottom: 2px solid #666;
  }

  .table-cell{
    padding: 20px 12px;
    color: #333;
  }

  .header-cell{
    color: #FFF;
    text-align: left;
  }

  .cell-actions{
    text-align: center;
    display: flex;
    flex-flow: row nowrap;
    justify-content: space-evenly;
  }
}
</style>
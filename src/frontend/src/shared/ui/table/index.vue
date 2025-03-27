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
      <th v-for="column in columns" class="table-cell header-cell">
        {{ column.label }}
      </th>
      <th v-if="hasActions" class="table-cell header-cell">
        Actions
      </th>
    </tr>
    </thead>
    <tbody v-if="rows" class="table-body">
    <tr v-for="row in rows" class="table-row">
      <td v-for="column in columns" class="table-cell">
        <pre>{{ row[column.key] }}</pre>
      </td>
      <td v-if="hasActions" class="table-cell cell-actions">
        <slot :row="row" name="data"></slot>
      </td>
    </tr>
    </tbody>
  </table>
</template>

<style scoped>
.table {
  width: 100%;
  border-collapse: collapse;

  & .table-header {
    background: #7A5CFA;
    font-size: 16px;

  }

  .table-row {
    border-bottom: 1px solid #666;
  }

  .header-row {
    border-top: 1px solid #666;
    border-bottom: 2px solid #666;
  }

  .table-cell {
    padding: 20px 12px;
    color: #333;
  }

  .header-cell {
    color: #FFF;
    text-align: left;
  }

  .cell-actions:not(:last-child) {
    margin-right: 16px;
  }
}
</style>
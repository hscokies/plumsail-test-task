<script setup>
import {RouterLink} from 'vue-router'
import {ROUTES} from "@/app/router/index.js";
import {Link, BarChart} from '@/shared/ui/icons'
import MockData from './data.json'
</script>

<template>
<table class="table">
  <thead class="table-header">
    <tr class="table-row header-row">
      <th class="table-cell header-cell">
        ID
      </th>
      <th class="table-cell header-cell">
        Title
      </th>
      <th class="table-cell header-cell">
        Subtitle
      </th>
      <th class="table-cell header-cell cell-actions">
        Actions
      </th>
    </tr>
  </thead>
  <tbody class="table-body">
    <tr class="table-row" v-for="row in MockData">
      <td class="table-cell" v-for="cell in row">
        {{cell}}
      </td>
      <td class="table-cell cell-actions">
        <RouterLink :to="`${ROUTES.Form}/${row.id}`" title="Get link" target="_blank">
          <Link/>
        </RouterLink>
        <RouterLink :to="`${ROUTES.Submissions}`" title="Get submissions">
          <BarChart/>
        </RouterLink>
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
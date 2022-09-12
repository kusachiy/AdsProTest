<template>
  <table class="table table-primary table-striped">
    <thead>
      <tr>
        <th scope="col">Country</th>
        <th scope="col">Requests</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="row in rows" :key="row.ClientCountry">
        <th>{{ row.clientCountry }}</th>
        <td>{{ row.requests }}</td>
      </tr>
    </tbody>
  </table>
</template>  
  <script>
import axios from "axios";
export default {
  data: () => ({   
    rows: [{ clientCountry: "US", requests: 100 }],
  }),
  mounted: async function () {
    let response = await axios.get(
      "https://localhost:7257/api/report/byrequest"
    );
    this.rows = response.data;
  },
};
</script>
  <style>
</style>
  
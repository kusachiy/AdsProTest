<template>
  <label for="selectControl" class="form-label">OS filter:</label>
  <select id="selectControl" class="form-select" @change="selectChanged">
    <option v-for="os in osDict" :key="os">{{ os }}</option>
  </select>

  <table class="table table-primary table-striped" style="margin-top: 10px">
    <thead>
      <tr>
        <th scope="col">Date</th>
        <th scope="col">Client ID</th>
        <th scope="col">Client IP</th>
        <th scope="col">Client Country</th>
        <th scope="col">OS</th>
        <th scope="col">Domain</th>
        <th scope="col">Site Country</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="row in filteredRequests" :key="row.clientId">
        <th>{{ formatTime(row.saveDt) }}</th>
        <td>{{ row.clientId }}</td>
        <td>{{ row.clientIp }}</td>
        <td>{{ row.clientCountry }}</td>
        <td>{{ row.os }}</td>
        <td>{{ row.domain }}</td>
        <td>{{ row.siteCountry }}</td>
      </tr>
    </tbody>
  </table>
</template>  
  <script>
import axios from "axios";
export default {
  data: () => ({
    osFilter: null,
    osDict: [],
    requests: [],
  }),
  computed: {
    filteredRequests: function () {
      if (!this.osFilter) return this.requests;
      return this.requests.filter((r) => r.os == this.osFilter);
    },
  },
  methods: {
    selectChanged: function (select) {
      this.osFilter = select.target.value;
    },
    formatTime(time) {
      let dt = new Date(time);
      return (
        dt.toLocaleDateString("fr-CA") + " " + dt.toLocaleTimeString("ru-RU")
      );
    },
  },
  mounted: function () {
    axios
      .get("https://localhost:7257/api/report/os_dictionary")
      .then((response) => {
        this.osDict = response.data;
        this.osDict.push(null);
        console.log(response);
      });
    axios
      .get("https://localhost:7257/api/report/byrequest")
      .then((response) => {
        this.requests = response.data;
        console.log(response);
      });
  },
};
</script>
  <style>
</style>
  
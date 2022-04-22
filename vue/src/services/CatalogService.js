import axios from "axios";

export default {
  /* REQUESTS */
  getExample(codeId) {
    // Get example by codeId
    return axios.get(`/example/${codeId}`);
  },

  getExamples() {
    // Get all examples by codeId
    return axios.get(`/example/status/1`);
  },

  getQuery(query) {
    // Send query to server and get results
    return axios.get(`example/search/${query}`);
  },

  /* POST REQUESTS */
  addExample(newExample, userId) {
    // Add an example to the DB
    return axios.post(`/example/${userId}`, newExample);
  },

  /* TO REMOVE */
  getGenericExamples() {
    // TODO
    return axios.get(`/example/set-list`);
  },

  fetchScript(codeId) {
    // TODO
    return axios.get(`/script/${codeId}`);
  },
};

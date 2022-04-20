import axios from "axios";

const baseUrl = "https://localhost:5001";
const http = axios.create({ baseURL: baseUrl });

export default {
  getExamples(userId) {
    return http.get(`/example/user-example/${userId}`);
  },
  getPending() {
    return http.get(`/example/status/0`);
  },
  updateStatus(codeId, example) {
    return http.put(`/example/update-status/${codeId}`, example)
  },
  // makePublic(codeId, example) {
  //   return http.put(`example/update-public/${codeId}`, example)
  // }
}
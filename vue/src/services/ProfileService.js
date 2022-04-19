import axios from "axios";

const baseUrl = "https://localhost:5001";
const http = axios.create({ baseURL: baseUrl });

export default {
  getExamples(userId) {
    return http.get(`/example/${userId}`);
  },
}
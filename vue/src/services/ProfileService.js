import axios from "axios";

export default {
  getExamples(userId) {
    // Get all examples by userId
    return axios.get(`/example/user-example/${userId}`);
  },
  getPending() {
    // Get all pending snippets
    return axios.get(`/example/status/0`);
  },
  updateStatus(codeId, example) {
    // Update status from default pending(0) to approved(1) or rejected(2) by codeId
    return axios.put(`/example/update-status/${codeId}`, example);
  },
  togglePrivacy(codeId, example) {
    // Make public or private by codeId
    return axios.put(`/example/update-public/${codeId}`, example);
  },
};

const _apiUrl = "/api/stories";

export const getAllStories = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

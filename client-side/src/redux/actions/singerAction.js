import { fetchSingersFromAPI } from '../../api/singerApi';

export const fetchSingersSuccess = (singers) => {
  return {
    type: 'FETCH_SINGERS_SUCCESS',
    singers,
  };
};

export const fetchSingers = () => {
  return async (dispatch) => {
    try {
      const singersWithImages = await fetchSingersFromAPI();
      dispatch(fetchSingersSuccess(singersWithImages));
    } catch (error) {
      console.error("Error fetching singers:", error);
      // Optionally dispatch a failure action here
    }
  };
};

const initialState = {
  singers: [], 
};

const singersReducer = (state = initialState, action) => {
  switch (action.type) {
    case 'FETCH_SINGERS_SUCCESS':
      return {
        ...state,
        singers: [ ...action.singers], 
      };
    default:
      return state;
  }
};

export default singersReducer;

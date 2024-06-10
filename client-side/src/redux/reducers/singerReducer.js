const initialState = {
  singers: [], // המערך של הזמרים
};

const singersReducer = (state = initialState, action) => {
  switch (action.type) {
    case 'FETCH_SINGERS_SUCCESS':
      return {
        ...state,
        singers: [ ...action.singers], // הוספת הנתונים מה-action לסוף המערך הקיים
      };
    default:
      return state;
  }
};

export default singersReducer;

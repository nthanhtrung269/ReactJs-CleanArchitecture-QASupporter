import {
    DBF2SQL_MAPPING_LIST_FAIL,
    DBF2SQL_MAPPING_LIST_REQUEST,
    DBF2SQL_MAPPING_LIST_SUCCESS
} from "../constants/dbf2SqlMappingConstants";

export const getAllDbf2SqlMappingByKeywordReducer = (state = { dbf2SqlMappings: [] }, action) => {
    switch (action.type) {
        case DBF2SQL_MAPPING_LIST_REQUEST:
            return { loading: true };
        case DBF2SQL_MAPPING_LIST_SUCCESS:
            return { loading: false, dbf2SqlMappings: action.payload };
        case DBF2SQL_MAPPING_LIST_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
};
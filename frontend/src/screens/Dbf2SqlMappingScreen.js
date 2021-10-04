import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router-dom';
import { getAllDbf2SqlMappingByKeyword } from '../actions/dbf2SqlMappingActions';
import LoadingBox from '../components/LoadingBox';
import MessageBox from '../components/MessageBox';
import SearchBox from '../components/SearchBox';

export default function Dbf2SqlMappingScreen(props) {
  // Document: https://stackoverflow.com/questions/35352638/react-how-to-get-parameter-value-from-query-string
  const keyword = new URLSearchParams(props.location.search).get("keyword");
  const modifiedBy = new URLSearchParams(props.location.search).get("modifiedBy");
  const dbf2SqlMappingList = useSelector((state) => state.getAllDbf2SqlMappingByKeyword);
  const { loading, error, dbf2SqlMappings } = dbf2SqlMappingList;
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllDbf2SqlMappingByKeyword({
      keyword: keyword ? keyword : '',
      modifiedBy: modifiedBy ? modifiedBy : 'Admin'
    }));
  }, [dispatch, keyword, modifiedBy]);

  return (
    <div>
      <h1>DBF to SQL Mapping</h1>
      <div className="row search-box-container">
        <SearchBox history={props.history}></SearchBox>
      </div>
      {loading ? (
        <LoadingBox></LoadingBox>
      ) : error ? (
        <MessageBox variant="danger">{error}</MessageBox>
      ) : (
        <table className="table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Foxpro Table</th>
              <th>Foxpro Column</th>
              <th>Sql Table</th>
              <th>Sql Column</th>
              <th>Notes</th>
              <th>Modified By</th>
              <th>Modified Date</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {dbf2SqlMappings.map((dbf2SqlMapping) => (
              <tr key={dbf2SqlMapping.Dbf2SqlMappingId}>
                <td>{dbf2SqlMapping.Dbf2SqlMappingId}</td>
                <td>{dbf2SqlMapping.FoxproTable}</td>
                <td>{dbf2SqlMapping.FoxproColumn}</td>
                <td>{dbf2SqlMapping.SqlTable}</td>
                <td>{dbf2SqlMapping.SqlColumn}</td>
                <td>{dbf2SqlMapping.Notes}</td>
                <td>{dbf2SqlMapping.ModifiedBy}</td>
                <td>{dbf2SqlMapping.ModifiedDate}</td>
                <td>
                  <button
                    type="button"
                    className="small"
                    onClick={() => {
                      props.history.push(`/dbf2sqlmapping/${dbf2SqlMapping.Dbf2SqlMappingId}`);
                    }}
                  >
                    Details
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
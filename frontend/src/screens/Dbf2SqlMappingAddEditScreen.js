import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import LoadingBox from '../components/LoadingBox';
import MessageBox from '../components/MessageBox';
import { createDbf2SqlMapping, editDbf2SqlMapping, getDbf2SqlMappingDetail } from '../actions/dbf2SqlMappingActions';
import { useAlert } from 'react-alert'
import { DBF2SQL_MAPPING_CREATE_RESET, DBF2SQL_MAPPING_DETAIL_RESET, DBF2SQL_MAPPING_EDIT_RESET } from '../constants/dbf2SqlMappingConstants';

// Understanding Functional Components vs. Class Components in React https://www.twilio.com/blog/react-choose-functional-components
// How To Convert React Class Components to Functional Components with React Hooks https://www.digitalocean.com/community/tutorials/five-ways-to-convert-react-class-components-to-functional-components-with-react-hooks
// https://nimblewebdeveloper.com/blog/convert-react-class-to-function-component
export default function Dbf2SqlMappingAddEditScreen(props) {
  const alert = useAlert();
  const dbf2SqlMappingId = props.match.params.id;
  const [foxproTable, setFoxproTable] = useState('');
  const [foxproColumn, setFoxproColumn] = useState('');
  const [sqlTable, setSqlTable] = useState('');
  const [sqlColumn, setSqlColumn] = useState('');
  const [notes, setNotes] = useState('');

  const dbf2SqlMappingCreate = useSelector((state) => state.dbf2SqlMappingCreate);
  const {
    loading: loadingUpdate,
    error: errorUpdate,
    success: successUpdate
  } = dbf2SqlMappingCreate;

  const dbf2SqlMappingEdit = useSelector((state) => state.dbf2SqlMappingEdit);
  const {
    loading: loadingEdit,
    error: errorEdit,
    success: successEdit
  } = dbf2SqlMappingEdit;

  const dbf2SqlMappingDetails = useSelector((state) => state.dbf2SqlMappingDetails);
  const { loading, error, dbf2SqlMappingDetail } = dbf2SqlMappingDetails;

  const dispatch = useDispatch();

  useEffect(() => {
    if (successUpdate) {
      alert.show('Success Create!');
      setFoxproTable('');
      setFoxproColumn('');
      setSqlTable('');
      setSqlColumn('');
      setNotes('');
      dispatch({ type: DBF2SQL_MAPPING_CREATE_RESET });
    }
    else if (errorUpdate) {
      alert.error(errorUpdate);
      dispatch({ type: DBF2SQL_MAPPING_CREATE_RESET });
    }

    if (successEdit) {
      alert.show('Success Update!');
      setFoxproTable('');
      setFoxproColumn('');
      setSqlTable('');
      setSqlColumn('');
      setNotes('');

      dispatch({ type: DBF2SQL_MAPPING_DETAIL_RESET });
      dispatch({ type: DBF2SQL_MAPPING_EDIT_RESET });
      props.history.push('/dbf2sqlmapping');
    }
    else if (errorEdit) {
      alert.error(errorEdit);
      dispatch({ type: DBF2SQL_MAPPING_EDIT_RESET });
    }

    if (dbf2SqlMappingId && dbf2SqlMappingId > 0) {
      if (!dbf2SqlMappingDetail) {
        dispatch(getDbf2SqlMappingDetail(dbf2SqlMappingId));
      }
      else {
        setFoxproTable(dbf2SqlMappingDetail.FoxproTable);
        setFoxproColumn(dbf2SqlMappingDetail.FoxproColumn);
        setSqlTable(dbf2SqlMappingDetail.SqlTable);
        setSqlColumn(dbf2SqlMappingDetail.SqlColumn);
        setNotes(dbf2SqlMappingDetail.Notes);
      }
    }
  }, [dbf2SqlMappingDetail, dispatch, dbf2SqlMappingId, errorUpdate, successUpdate, errorEdit, successEdit]);

  const isEdit = () => {
    return dbf2SqlMappingId && dbf2SqlMappingId > 0;
  };

  const submitHandler = (e) => {
    e.preventDefault();

    if (isEdit()) {
      dispatch(
        editDbf2SqlMapping({
          dbf2SqlMappingId,
          foxproTable,
          foxproColumn,
          sqlTable,
          sqlColumn,
          notes
        })
      );
    }
    else {
      dispatch(
        createDbf2SqlMapping({
          foxproTable,
          foxproColumn,
          sqlTable,
          sqlColumn,
          notes
        })
      );
    }
  };

  return (
    <div>
      <form className="form" onSubmit={submitHandler}>
        <div>
          <h1>{isEdit() ? "Edit" : "Add"} Dbf2SqlMapping</h1>
        </div>
        {loading ? (
          <LoadingBox></LoadingBox>
        ) : error ? (
          <MessageBox variant="danger">{error}</MessageBox>
        ) : (
          <>
            <div>
              <label htmlFor="foxproTable">Foxpro Table</label>
              <input
                id="foxproTable"
                type="text"
                placeholder="Enter Foxpro Table (required)"
                value={foxproTable}
                required
                onChange={(e) => setFoxproTable(e.target.value)}
              ></input>
            </div>
            <div>
              <label htmlFor="foxproColumn">Foxpro Column</label>
              <input
                id="foxproColumn"
                type="text"
                placeholder="Enter Foxpro Column"
                value={foxproColumn}
                onChange={(e) => setFoxproColumn(e.target.value)}
              ></input>
            </div>
            <div>
              <label htmlFor="sqlTable">Sql Table</label>
              <input
                id="sqlTable"
                type="text"
                placeholder="Enter Sql Table (required)"
                value={sqlTable}
                required
                onChange={(e) => setSqlTable(e.target.value)}
              ></input>
            </div>
            <div>
              <label htmlFor="category">Sql Column</label>
              <input
                id="sqlColumn"
                type="text"
                placeholder="Enter Sql Column"
                value={sqlColumn}
                onChange={(e) => setSqlColumn(e.target.value)}
              ></input>
            </div>
            <div>
              <label htmlFor="brand">Notes</label>
              <textarea
                id="notes"
                rows="3"
                type="text"
                placeholder="Enter Notes"
                value={notes}
                onChange={(e) => setNotes(e.target.value)}
              ></textarea>
            </div>
            <div>
              <label></label>
              <button className="primary" type="submit">
                Save
              </button>
            </div>
          </>
        )}
      </form>
      <br />
      <div className="row">
        <button
          type="button"
          className="small"
          onClick={() => {
            props.history.push('/dbf2sqlmapping');
          }}
        >
          Back To List
        </button>
      </div>
    </div>
  );
}

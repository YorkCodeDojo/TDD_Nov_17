SET (M3RDPARTY_DIR ${CMAKE_CURRENT_LIST_DIR})

LIST(APPEND M3RDPARTY_INCLUDE
    m3rdparty
    ${CMAKE_BINARY_DIR}
    ${M3RDPARTY_DIR}/googletest
    ${M3RDPARTY_DIR}/googletest/googletest/include
    ${M3RDPARTY_DIR}/googletest/googletest
    ${M3RDPARTY_DIR}/googletest/googlemock/include
    ${M3RDPARTY_DIR}/googletest/googlemock
    )

SOURCE_GROUP ("m3rdparty\\googletest" REGULAR_EXPRESSION "(googlete)+.*") 

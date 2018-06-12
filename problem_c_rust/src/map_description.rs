use std;

pub struct MapDescription {
    pub width: i32,
    pub height: i32,
    pub start: i32,
    pub end: i32,
    pub map: std::vec::Vec<u8>
}